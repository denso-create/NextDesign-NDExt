using NDExt.Utils;
using System;
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
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        protected NewCommandBase(string name, string description) : base(name, description)
        {
            AddArgument<string>("name", "作成プロジェクト名を指定して下さい");

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
                WriteLine($"# ---------------------------------------------------------------");
                WriteLine($"# Creating Next Design Extension Solution & Project");
                WriteLine($"# ");
                WriteLine($"# Project Name: '{name}'");
                WriteLine($"# Template Type: '{TemplateName}'");
                WriteLine($"# Template Description: '{TemplateDescription}'");
                WriteLine($"# ---------------------------------------------------------------");

                // ソリューションを作成または検索します。
                var slnFile = CreateOrGetSolution(name);

                // プロジェクトを作成します。
                var projFile = CreateProject(name, TemplateName);

                ProcessUtil.Start("dotnet", $@"sln ""{slnFile}"" add ""{projFile}"" ");

                WriteLine("完了しました。");
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
            var slnFile = Directory.EnumerateFiles(CurrentDir, "*.sln").FirstOrDefault();

            if (!string.IsNullOrEmpty(slnFile))
            {
                WriteLine($"ソリューションファイル `{Path.GetFileName(slnFile)}` を検出しました。このファイルにプロジェクトを追加します。");
                return slnFile;
            }

            slnFile = Path.Combine(CurrentDir, $"{projectName}.sln");
            WriteLine($"ソリューションファイルを作成します。 {slnFile}");

            // ソリューションを作成する
            ExecuteProcess("dotnet", $"new sln -n {projectName}");

            return slnFile;
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
                throw new UserException("プロジェクトファイルがすでに存在しているため処理を中止します。");
            }

            // プロジェクトを作成
            ExecuteProcess("dotnet", @$"new {templateName} -n {projectName} -o ""{projectDir}"" --force");
            var projFile = NDExtensionProjectFileUtil.GetProjectFilePath(projectDir);

            if (string.IsNullOrEmpty(projFile))
            {
                throw new UserException("プロジェクトファイルの作成に失敗しました。");
            }

            WriteLine($"{projectDir}に `{Path.GetFileName(projFile)}` を作成しました。");

            return projFile;
        }

        #endregion
    }
}
