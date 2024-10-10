using NDExt.Properties;
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
        #region 定数定義

        /// <summary>
        /// Nuspecのプロジェクトノードを示すXMLノード名。
        /// </summary>
        private const string c_ProjectNodeName = "Project";

        /// <summary>
        /// NuspecのパッケージIDを示すXMLノード名。
        /// </summary>
        private const string c_PackageIdNodeName = "packageid";

        /// <summary>
        /// Nuspecのバージョンを示すXMLノード名。
        /// </summary>
        private const string c_VersionNodeName = "version";

        /// <summary>
        /// Nuspecの説明を示すXMLノード名。
        /// </summary>
        private const string c_DescriptionNodeName = "description";

        /// <summary>
        /// NuspecのプロジェクトURLを示すXMLノード名。
        /// </summary>
        private const string c_PackageProjectUrlNodeName = "packageprojecturl";

        /// <summary>
        /// Nuspecの著者情報を示すXMLノード名。
        /// </summary>
        private const string c_AuthorsNodeName = "authors";

        /// <summary>
        /// Nuspecの著作権情報を示すXMLノード名。
        /// </summary>
        private const string c_CopyrightNodeName = "copyright";

        #endregion

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
        /// NuspecのメタデータをXML形式の文字列として返します。
        /// </summary>
        /// <returns>メタデータを表すXML文字列。</returns>
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
        /// Nuspec情報を指定されたファイルパスに保存します。
        /// </summary>
        /// <param name="filepath">保存先のファイルパス。</param>
        public void SaveToFile(string filepath)
        {
            var xml = ToXmlString();
            File.WriteAllText(filepath, xml, Encoding.UTF8);
        }

        /// <summary>
        /// 指定されたプロジェクトファイルからNuspec情報を抽出して返します。
        /// </summary>
        /// <param name="projectFilePath">プロジェクトファイルのパス。</param>
        /// <returns>Nuspec情報を格納した <see cref="NdPackageNuspecInfo"/> オブジェクト。</returns>
        public static NdPackageNuspecInfo CreateFromProjectFile(string projectFilePath)
        {
            // XMLドキュメントを読み込みプロジェクトノードを取得する
            var projectXml = new XmlDocument();
            projectXml.Load(projectFilePath);
            var projectNode = projectXml.SelectSingleNode(c_ProjectNodeName);

            var nuspec = new NdPackageNuspecInfo();

            // プロジェクト内の全ての子ノードを走査する
            foreach (XmlNode node in projectNode.ChildNodes)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    // ノードの名前と内容を取得しオブジェクトに設定
                    var name = item.Name.ToLower();
                    var val = item.InnerText;
                    SetNuspecProperty(ref nuspec, name, val);
                }
            }

            return nuspec;
        }

        /// <summary>
        /// 必要なNuspec情報が正しく指定されているかチェックします。
        /// </summary>
        /// <exception cref="UserException">必須のフィールドが指定されていない場合にスローされます。</exception>
        public void CheckErrors()
        {
            // エラーチェック
            if (string.IsNullOrEmpty(Id)) throw new UserException(Strings.ErrorPackageIdNotSpecified0);
            if (string.IsNullOrEmpty(Authors)) throw new UserException(Strings.ErrorAuthorsNotSpecified0);
            if (string.IsNullOrEmpty(Description)) throw new UserException(Strings.ErrorDescriptionNotSpecified0);
            if (string.IsNullOrEmpty(Version)) throw new UserException(Strings.ErrorVersionNotSpecified0);
        }

        #endregion

        #region 内部メソッド

        /// <summary>
        /// 指定されたNuspecオブジェクトのプロパティに、XMLノードの内容を設定します。
        /// </summary>
        /// <param name="nuspec">Nuspec情報を格納するオブジェクト。</param>
        /// <param name="name">XMLノード名。</param>
        /// <param name="value">XMLノードの内容。</param>
        private static void SetNuspecProperty(ref NdPackageNuspecInfo nuspec, string name, string value)
        {
            // 改行コードを統一します
            value = value.Replace("\r\n", "\n");

            // Nuspec情報をオブジェクトに設定
            switch (name)
            {
                case c_PackageIdNodeName:
                    nuspec.Id = value;
                    break;
                case c_VersionNodeName:
                    nuspec.Version = value;
                    break;
                case c_DescriptionNodeName:
                    nuspec.Description = value;
                    break;
                case c_PackageProjectUrlNodeName:
                    nuspec.ProjectUrl = value;
                    break;
                case c_AuthorsNodeName:
                    nuspec.Authors = value;
                    break;
                case c_CopyrightNodeName:
                    nuspec.Copyright = value;
                    break;
            }
        }

        #endregion
    }
}
