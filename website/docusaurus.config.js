// @ts-check
// Note: type annotations allow type checking and IDEs autocompletion

const lightCodeTheme = require('prism-react-renderer/themes/github');
const darkCodeTheme = require('prism-react-renderer/themes/dracula');

/** @type {import('@docusaurus/types').Config} */
const config = {
  title: 'NDExt',
  tagline: 'Next Design エクステンション開発ユーティリティ',
  url: 'http://denso-create.github.io',
  baseUrl: '/NextDesign-NDExt/',
  onBrokenLinks: 'warn',
  onBrokenMarkdownLinks: 'warn',
  favicon: 'img/favicon.ico',
  organizationName: 'densocreate', // Usually your GitHub org/user name.
  projectName: 'NextDesign-NDExt', // Usually your repo name.

  presets: [
    [
      '@docusaurus/preset-classic',
      /** @type {import('@docusaurus/preset-classic').Options} */
      ({
        docs: {
          sidebarPath: require.resolve('./sidebars.js'),
          routeBasePath: '/',
          editUrl: 'https://github.com/denso-create/NextDesign-NDExt/tree/main/website/docs',
        },
        theme: {
          customCss: require.resolve('./src/css/custom.css'),
        },
      }),
    ],
  ],

  themeConfig:
    /** @type {import('@docusaurus/preset-classic').ThemeConfig} */
    ({
      navbar: {
        title: 'NDExt',
        logo: {
          alt: 'NDExt',
          src: 'img/logo.svg',
        },
        items: [
          {
            type: 'doc',
            docId: 'intro',
            position: 'left',
            label: 'Docs',
          },
          // {
          //   to: '/blog',
          //   label: 'Releases',
          //   position: 'left'
          // },
          {
            href: 'https://www.nuget.org/packages/NDExt/',
            label: 'Install',
            position: 'left',
          },
          {
            href: 'https://github.com/denso-create/NextDesign-NDExt',
            label: 'Github',
            position: 'right',
          },
          {
            href: 'https://www.nextdesign.app/',
            label: 'Next Design',
            position: 'right',
          },
        ],
      },
      footer: {
        style: 'dark',
        links: [
          {
            title: 'Docs',
            items: [
              {
                label: 'Tutorial',
                to: '/docs',
              },
            ],
          },
          {
            title: 'Related Links',
            items: [
              {
                href: 'https://www.nextdesign.app/',
                label: 'Next Design',
              },
              {
                label: 'Github',
                href: 'https://github.com/denso-create/NextDesign-NDExt',
              },
            ],
          },
          {
            title: 'Company',
            items: [
              {
                label: 'DENSO CREATE',
                href : 'https://www.denso-create.jp/',
              },
            ],
          },
        ],
        copyright: `Copyright © ${new Date().getFullYear()} DENSO CREATE INC. All rights reserved.`,
      },
      prism: {
        theme: lightCodeTheme,
        darkTheme: darkCodeTheme,
      },
    }),
};

module.exports = config;
