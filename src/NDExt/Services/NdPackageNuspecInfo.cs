using System.IO;
using System.Text;
using System.Xml;

namespace NDExt.Services
{
    /// <summary>
    /// Nuspecのメタデータ
    /// </summary>
    public class NdPackageNuspecInfo
    {
        #region 構築・消滅

        /// <summary>
        /// コンストラクタ。
        /// </summary>
        public NdPackageNuspecInfo() { }

        #endregion

        #region プロパティ

        /// <summary>
        /// パッケージIdを取得または設定します。
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 説明を取得または設定します。
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Urlを取得または設定します。
        /// </summary>
        public string ProjectUrl { get; set; }

        /// <summary>
        /// バージョンを取得または設定します。
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Copyrightを取得または設定します。
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// Authorsを取得または設定します。
        /// </summary>
        public string Authors { get; set; }

        #endregion

        #region 公開メソッド

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
    <description>{Description}</description>
    <authors>{Authors}</authors>
    <owners>{Authors}</owners>
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

            foreach (XmlNode node in projectNode.ChildNodes)
            {

                // 情報を抜き出します
                foreach (XmlNode item in node.ChildNodes)
                {
                    var name = item.Name.ToLower();
                    var val = item.InnerText;

                    if (val == null) continue;

                    // 改行コードを統一します
                    val = val.Replace("\r\n", "\n");

                    switch (name)
                    {
                        case "packageid":
                            nuspec.Id = val;
                            break;

                        case "version":
                            nuspec.Version = val;
                            break;

                        case "description":
                            nuspec.Description = val;
                            break;

                        case "packageprojecturl":
                            nuspec.ProjectUrl = val;
                            break;

                        case "authors":
                            nuspec.Authors = val;
                            break;

                        case "copyright":
                            nuspec.Copyright = val;
                            break;
                    }
                }
            }

            return nuspec;
        }

        /// <summary>
        /// エラーチェック
        /// </summary>
        public void CheckErrors()
        {
            // エラーチェック
            if (string.IsNullOrEmpty(Id)) throw new UserException($"csprojファイルにパッケージId（`PackageId`）を指定して下さい。");
            if (string.IsNullOrEmpty(Id)) throw new UserException($"csprojファイルに作成者（`Authors`）を指定して下さい。");
            if (string.IsNullOrEmpty(Description)) throw new UserException($"csprojファイルで説明（`Description`）を指定して下さい。");
            if (string.IsNullOrEmpty(Version)) throw new UserException($"csprojファイルでパッケージバージョンが指定されていません。バージョン（`Version`）を指定して下さい。");
        }

        #endregion
    }
}
