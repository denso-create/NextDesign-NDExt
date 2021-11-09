using NDExt.Utils;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;

namespace NDExt.Commands
{
    /// <summary>
    /// 新規コマンドのベース
    /// </summary>
    public abstract class NewCommandBase : CommandBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public NewCommandBase(string name,string description) : base(name,description)
        {
            AddArgument<string>("name","作成プロジェクト名を指定して下さい");

            Handler = CommandHandler.Create<string>(Handle);
        }

        /// <summary>
        /// ハンドラ
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int Handle(string name)
        {
            try {
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
            } catch (Exception ex)
            {
                WriteError(ex);
                return cFail;
            }

            return cSuccess;
        }

        protected abstract string TemplateName { get; }

        protected abstract string TemplateDescription { get; }


        /// <summary>
        /// ソリューションファイルを取得または作成します
        /// </summary>
        /// <param name="projectName"></param>
        /// <returns></returns>
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
            ExcecuteProcess("dotnet", $"new sln -n {projectName}");

            return slnFile;
        }

        /// <summary>
        /// プロジェクトを作成します
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="templateName"></param>
        /// <returns></returns>
        protected string  CreateProject(string projectName,string templateName)
        {
            var projectDir = Path.Combine(CurrentDir, projectName);

            // ディレクトリ作成
            if ( !Directory.Exists(projectDir))
            {
                Directory.CreateDirectory(projectDir);
            }

            if ( NDExtensionProjectFileUtil.ProjectFileExists(projectDir) )
            {
                throw new UserException("プロジェクトファイルがすでに存在しているため処理を中止します。");
            }

            // プロジェクトを作成
            ExcecuteProcess("dotnet", @$"new {templateName} -n {projectName} -o ""{projectDir}"" --force");
            var projFile = NDExtensionProjectFileUtil.GetProjectFilePath(projectDir);

            if ( string.IsNullOrEmpty(projFile))
            {
                throw new UserException("プロジェクトファイルの作成に失敗しました。");
            }
            
            WriteLine($"{projectDir}に `{Path.GetFileName(projFile)}` を作成しました。");

            return projFile;
        }


    }
}
