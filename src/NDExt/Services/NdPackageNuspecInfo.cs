using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace NDExt.Services
{
    /// <summary>
    /// Nuspecのメタデータ
    /// </summary>
    public class NdPackageNuspecInfo
    {
        public NdPackageNuspecInfo()
        {
        }

        /// <summary>
        /// パッケージId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 説明
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string ProjectUrl { get; set; } = "https://www.nextdesign.app/";

        /// <summary>
        /// バージョン
        /// </summary>
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        /// Copyright
        /// </summary>
        public string Copyright { get; set; } = $"Copyright(C) {DateTime.Today.Year} (Your Company Here) All Rights Reserved.";

        public string Author { get; set; } = "(Your Company Here)";

        /// <summary>
        /// Xml文字列として戻します
        /// </summary>
        /// <returns></returns>
        public string ToXmlString()
        {
            var xml =
@$"<?xml version=""1.0"" encoding=""utf - 8""?>
  <package xmlns = ""http://schemas.microsoft.com/packaging/2011/08/nuspec.xsd"" >
  <metadata>
    <id>{Id}</id>
    <version>{Version}</version>
    <title>{Title}</title>
    <description>{Description}</description>
    <authors>{Author}</authors>
    <owners>{Author}</owners>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <projectUrl>{ProjectUrl}</projectUrl>
    <releaseNotes></releaseNotes>
    <copyright>{Copyright}</copyright>
  </metadata>
</package>";

            return xml;
        }

        /// <summary>
        /// ファイルに保存します
        /// </summary>
        /// <param name="filepath"></param>
        public void SaveToFile(string filepath)
        {
            var xml = ToXmlString();
            File.WriteAllText(filepath, xml, Encoding.UTF8);

        }

        /// <summary>
        /// Nuspec情報を抜き出します
        /// </summary>
        /// <param name="projectFilePath"></param>
        /// <returns></returns>
        public static NdPackageNuspecInfo CreateFromProjectFile(string projectFilePath)
        {
            var projectXml = new XmlDocument();
            projectXml.Load(projectFilePath);
            var projectNode = projectXml.SelectSingleNode("Project");
            var nuspec = new NdPackageNuspecInfo();
            var nuspecDescription = "";

            foreach (XmlNode node in projectNode.ChildNodes)
            {

                // 情報を抜き出します
                foreach (XmlNode item in node.ChildNodes)
                {
                    var name = item.Name.ToLower();
                    var val = item.InnerText;

                    switch (name)
                    {
                        case "version":
                            nuspec.Version = val;
                            break;

                        case "description":
                            nuspecDescription = val;
                            break;

                        case "packageid":
                            nuspec.Id = val;
                            break;

                        case "packageprojecturl":
                            nuspec.ProjectUrl = val;
                            break;
                    }
                }
            }

            // パッケージの説明の１行目をタイトルとして、２行目以降は説明として抜き出す
            nuspec.Title = nuspecDescription.Split("\r\n").FirstOrDefault()?.Trim();
            nuspec.Description = string.Join("\r\n", nuspecDescription.Split("\r\n").Skip(1))?.Trim();

            return nuspec;
        }


        /// <summary>
        /// エラーチェック
        /// </summary>
        public void CheckErrors()
        {
            // エラーチェック
            if (string.IsNullOrEmpty(Id)) throw new UserException($"csprojファイルにパッケージId（`PackageId`）を指定して下さい。");
            if (string.IsNullOrEmpty(Description)) throw new UserException($"csprojファイルで説明（`Description`）が空です。説明欄の1行目にタイトル、2行目以降にパッケージの説明となるように記載して下さい。");
            if (string.IsNullOrEmpty(Version)) throw new UserException($"csprojファイルでパッケージバージョンが指定されていません。バージョン（`Version`）を指定して下さい。");

        }
    }

}
