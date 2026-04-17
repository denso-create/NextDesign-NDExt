using NDExt.Properties;
using NDExt.Utils;
using System;
using System.Collections.Generic;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;

namespace NDExt.Commands
{
    /// <summary>
    /// エクステンションプロジェクトの新規作成を実行するコマンドのベースクラスです。
    /// </summary>
    public abstract class NewCommandBase : CommandBase
    {
        #region 定数定義

        /// <summary>
        /// ソリューションファイルの拡張子。
        /// </summary>
        /// <remarks>>
        /// 優先して使用したい拡張子を先に記載すること。
        /// </remarks>
        private static readonly string[] c_SolutionFileExtensions = [".slnx", ".sln"];

        #endregion

        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name">コマンド名。</param>
        /// <param name="description">コマンドの説明。</param>
        protected NewCommandBase(string name, string description) : base(name, description)
        {
            AddArgument<string>("name", Strings.DescriptionNewCommandProjectName0);

            Handler = CommandHandler.Create<string>(Handle);
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// プロジェクトテンプレート名を取得します。
        /// </summary>
        protected abstract string TemplateName { get; }

        /// <summary>
        /// プロジェクトテンプレートの説明を取得します。
        /// </summary>
        protected abstract string TemplateDescription { get; }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// プロジェクトの作成処理を実行するハンドラメソッド。
        /// </summary>
        /// <param name="name">作成プロジェクト名</param>
        /// <returns>終了コード。成功時は<see cref="CommandBase.Success"/>、失敗時は<see cref="CommandBase.Fail"/>を返します。</returns>
        private int Handle(string name)
        {
            try
            {
                ConsoleUtil.WriteHeader(string.Format(Strings.HeaderCreatingExtensionProjectDetails3, name, TemplateName, TemplateDescription));

                // ソリューションを作成または検索します。
                var slnFile = CreateOrGetSolution(name);

                // プロジェクトを作成します。
                var projFile = CreateProject(name, TemplateName);

                ProcessUtil.Start("dotnet", $@"sln ""{slnFile}"" add ""{projFile}"" ");

                WriteLine(Strings.LogCompletion0);
            }
            catch (Exception ex)
            {
                WriteError(ex);
                return Fail;
            }

            return Success;
        }

        /// <summary>
        /// ソリューションファイルを取得または作成します
        /// </summary>
        /// <param name="projectName">作成するプロジェクト名</param>
        /// <returns>ソリューションファイルのパス。</returns>
        protected string CreateOrGetSolution(string projectName)
        {
            var slnFile = EnumerateSolution(CurrentDir).FirstOrDefault();

            if (!string.IsNullOrEmpty(slnFile))
            {
                WriteLine(string.Format(Strings.LogSolutionFileDetected1, Path.GetFileName(slnFile)));
                return slnFile;
            }

            // ソリューションを作成する
            ExecuteProcess("dotnet", $"new sln -n {projectName}");

            slnFile = EnumerateSolution(CurrentDir).FirstOrDefault();
            WriteLine(string.Format(Strings.LogCreatedSolutionFile1, slnFile));

            return slnFile;
        }

        /// <summary>
        /// フォルダ内のソリューションファイルを列挙します。
        /// </summary>
        /// <param name="path">検索対象のフォルダパス。</param>
        /// <returns>ソリューションファイルの列挙。</returns>
        private IEnumerable<string> EnumerateSolution(string path)
        {
            var patterns = c_SolutionFileExtensions.Select(ext => $"*{ext}");
            return EnumerateFilesMultiPattern(path, patterns);
        }

        /// <summary>
        /// フォルダ内のパターンに一致するファイルを列挙します。
        /// </summary>
        /// <param name="path">検索対象のフォルダパス。</param>
        /// <param name="patterns">検索パターンの列挙。</param>
        /// <returns>一致するファイルの列挙。</returns>
        private IEnumerable<string> EnumerateFilesMultiPattern(string path, IEnumerable<string> patterns)
        {
            foreach (var pattern in patterns)
            {
                foreach (var foundPath in Directory.EnumerateFiles(path, pattern))
                {
                    yield return foundPath;
                }
            }
        }

        /// <summary>
        /// プロジェクトを作成します
        /// </summary>
        /// <param name="projectName">作成するプロジェクト名</param>
        /// <param name="templateName">作成時に利用するプロジェクトテンプレート名</param>
        /// <returns>プロジェクトのパス。</returns>
        protected string CreateProject(string projectName, string templateName)
        {
            var projectDir = Path.Combine(CurrentDir, projectName);

            // ディレクトリ作成
            if (!Directory.Exists(projectDir))
            {
                Directory.CreateDirectory(projectDir);
            }

            if (NDExtensionProjectFileUtil.ProjectFileExists(projectDir))
            {
                throw new UserException(Strings.ErrorProjectFileAlreadyExists0);
            }

            // プロジェクトを作成
            ExecuteProcess("dotnet", @$"new {templateName} -n {projectName} -o ""{projectDir}"" --force");
            var projFile = NDExtensionProjectFileUtil.GetProjectFilePath(projectDir);

            if (string.IsNullOrEmpty(projFile))
            {
                throw new UserException(Strings.ErrorProjectFileCreationFailed0);
            }

            WriteLine(string.Format(Strings.LogProjectFileCreated2, projectDir, Path.GetFileName(projFile)));

            return projFile;
        }

        #endregion
    }
}
