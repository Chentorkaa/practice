/* eslint-disable @typescript-eslint/no-var-requires */
const path = require('path')

const autoprefixer = require('autoprefixer')
const { CleanWebpackPlugin } = require('clean-webpack-plugin')
const CompressionPlugin = require('compression-webpack-plugin')
const CopyPlugin = require('copy-webpack-plugin')
const MiniCssExtractPlugin = require('mini-css-extract-plugin')
const HtmlPlugin = require('html-webpack-plugin')
const TerserJSPlugin = require('terser-webpack-plugin')
const OptimizeCSSAssetsPlugin = require('optimize-css-assets-webpack-plugin')
const ForkTsCheckerWebpackPlugin = require('fork-ts-checker-webpack-plugin')
const webpack = require('webpack')

const stringify = (obj) => Object
  .keys(obj)
  .reduce((acc, v) => {
    acc[v] = JSON.stringify(obj[v])
    return acc
  }, {})

const PRODUCTION = 'production'
const DEVELOPMENT = 'development'
const INDEX_TSX = 'index.tsx'
const URL = 'https://test.teamjet.ru'

const GOOGLE_ANALYTICS_TRACKING_ID = 'UA-136901954-1'
const YANDEX_ANALYTICS_TRACKING_ID = 53862376

// paths
const PROJECT_ROOT = __dirname
const PATH_SRC = path.resolve(PROJECT_ROOT, 'src')
const PATH_DIST = path.resolve(PROJECT_ROOT, 'dist')

// variables
const COMMIT_HASH = process.env.COMMIT_HASH || ''
const ENTRY = process.env.ENTRY || INDEX_TSX
const CHECKER = 'checker.js'
const DEVTOOL_TYPE = process.env.DEVTOOL_TYPE || 'inline-source-map'

const autoprefix = autoprefixer({
  grid: 'autoplace',
})

const ExtractCss = new MiniCssExtractPlugin({
  filename: 'app.[contenthash].css',
})

module.exports = (env, argv) => {
  const MODE = argv ? argv.mode : DEVELOPMENT
  const IS_PROD = MODE === PRODUCTION

  /* eslint-disable-next-line no-console */
  console.log(`
    COMMIT_HASH=${COMMIT_HASH}
    ENTRY=${ENTRY}
    MODE=${MODE}

    URL=${URL}
    IS_PROD=${IS_PROD}
  `)

  let entry = [path.resolve(PATH_SRC, ENTRY)]
  if (IS_PROD) {
    entry = [
      path.resolve(PATH_SRC, CHECKER),
      'core-js/fn/object/assign',
      'core-js/es6/array',
      'core-js/es6/map',
      'core-js/es6/set',
      'core-js/es6/promise',
      'core-js/es6/string',
      'core-js/es6/number',
      'blueimp-canvas-to-blob',
      'intl',
      // todo move to dinamic loading
      'intl/locale-data/jsonp/en.js',
      'intl/locale-data/jsonp/ru.js',
      'intl/locale-data/jsonp/zh.js',
    ].concat(entry)
  }

  return {
    stats: {
      all: false,
      assets: IS_PROD,
      timings: true,
      performance: true,
      warnings: true,
      errors: true,
    },
    performance: {
      hints: false,
    },
    optimization: {
      minimizer: [new TerserJSPlugin(), new OptimizeCSSAssetsPlugin()],
    },
    bail: IS_PROD,
    devtool: IS_PROD ? 'source-map' : DEVTOOL_TYPE,
    entry,
    module: {
      rules: [
        {
          test: /\.tsx?$/,
          use: [
            {
              loader: 'ts-loader',
              options: {
                configFile: 'tsconfig.json',
                happyPackMode: true,
                transpileOnly: true,
                getCustomTransformers: path.resolve(__dirname, './webpack.ts-transformers.js'),
              },
            },
          ],
        },
        {
          test: /\.(sa|sc)ss$/,
          use: [
            {
              loader: MiniCssExtractPlugin.loader,
              options: {
                hmr: !IS_PROD,
              },
            },
            {
              loader: 'css-loader',
              options: {
                sourceMap: true,
                modules: {
                  localIdentName: '[name]--[local]--[hash:base64:5]',
                },
              },
            },
            IS_PROD && {
              loader: 'postcss-loader',
              options: {
                ident: 'postcss',
                plugins: [
                  autoprefix,
                ],
                sourceMap: true,
              },
            },
            {
              loader: 'sass-loader',
              options: {
                includePaths: [path.resolve(PATH_SRC, 'styles')],
                sourceMap: true,
              },
            },
          ].filter(Boolean),
        },
        {
          test: /\.css$/,
          use: [
            {
              loader: MiniCssExtractPlugin.loader,
              options: {
                hmr: !IS_PROD,
              },
            },
            {
              loader: 'css-loader',
              options: {
                sourceMap: true,
              },
            },
            IS_PROD && {
              loader: 'postcss-loader',
              options: {
                ident: 'postcss',
                plugins: [
                  autoprefix,
                ],
                sourceMap: true,
              },
            },
          ].filter(Boolean),
        },
        {
          test: /\.less$/,
          use: [
            {
              loader: MiniCssExtractPlugin.loader,
              options: {
                hmr: !IS_PROD,
              },
            },
            {
              loader: 'css-loader',
              options: {
                sourceMap: true,
              },
            },
            {
              loader: 'postcss-loader',
              options: {
                sourceMap: true,
                plugins: [
                  autoprefix,
                ],
              },
            },
            {
              loader: 'less-loader',
              options: {
                sourceMap: true,
                javascriptEnabled: true,
                modifyVars: {
                  '@primary-color': '#55A4FF',
                  '@font-family': '"Montserrat", -apple-system, BlinkMacSystemFont, "Segoe UI", sans-serif',
                  '@body-background': '#fff',
                },
              },
            },
          ],
        },
        {
          test: /\.svg$/,
          loader: 'svg-url-loader',
        },
        {
          test: /\.(jpg|jpeg|png)$/,
          loader: 'url-loader',
          options: {
            limit: 10 * 1024,
            fallback: 'file-loader',
          },
        },
        {
          test: /\.mp3$/,
          loader: 'file-loader',
        },
        {
          test: /\.(woff|woff2|eot|ttf|otf)$/,
          use: [
            'file-loader',
          ],
        },
      ],
    },
    plugins: [
      new ForkTsCheckerWebpackPlugin({
        tsconfig: path.resolve(PATH_SRC, 'tsconfig.json'),
        eslint: true,
        checkSyntacticErrors: true,
      }),
      new webpack.DefinePlugin(stringify({
        COMMIT_HASH,
        GOOGLE_ANALYTICS_TRACKING_ID,
        YANDEX_ANALYTICS_TRACKING_ID,
      })),
      ExtractCss,
      new HtmlPlugin({
        template: path.resolve(PATH_SRC, 'index.html.ejs'),
        title: 'TeamJet',
        v: {
          GOOGLE_ANALYTICS_TRACKING_ID: IS_PROD && GOOGLE_ANALYTICS_TRACKING_ID,
          YANDEX_ANALYTICS_TRACKING_ID: IS_PROD && YANDEX_ANALYTICS_TRACKING_ID,
        },
      }),
      IS_PROD && new CleanWebpackPlugin(),
      IS_PROD && new CopyPlugin([
        {
          from: 'assets',
          to: path.resolve(PATH_DIST, 'assets'),
        },
        { from: './src/bad_browser.html', to: path.resolve(PATH_DIST, 'bad_browser/index.html') },
        { from: 'robots.txt', to: path.resolve(PATH_DIST, 'robots.txt') },
      ]),
      IS_PROD && new CompressionPlugin(),
    ].filter(Boolean),
    output: {
      path: PATH_DIST,
      filename: 'bundle.[hash].min.js',
      publicPath: '/',
    },
    resolve: {
      extensions: ['.json', '.js', '.jsx', '.ts', '.tsx'],
      modules: [].concat(PATH_SRC, 'node_modules'),
    },
    target: 'web',
    externals: ['fs'],
    devServer: {
      historyApiFallback: true,
      host: '0.0.0.0',
      allowedHosts: [
        '.teamjet.localtest',
      ],
      proxy: {
        '/api/': {
          changeOrigin: true,
          // target: 'http://192.168.150.22:3000',
          target: URL,
          // target: 'http://localhost:3000',
          // pathRewrite: {
          //   '^/api/': '/staff/'
          // },
        },
        '/md/listen': {
          changeOrigin: true,
          // target: 'http://localhost:8082',
          target: URL,
          // pathRewrite: {
          // '^/md/listen': '/api/listen'
          // },
          ws: true,
        },
        '/files/': {
          changeOrigin: true,
          target: URL,
        },
        '/md/': {
          changeOrigin: true,
          // target: 'http://localhost:8080',
          target: URL,
          // pathRewrite: {
          //   '^/md/': '/api/'
          // },
        },
        '/reporter/': {
          target: URL,
          changeOrigin: true,
        },
        '/whats-new-api/': {
          target: URL,
          changeOrigin: true,
        },
      },
    },
  }
}

module.exports.ExtractCss = ExtractCss
