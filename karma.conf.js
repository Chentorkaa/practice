const path = require('path')

const webpackConfFunc = require('./webpack.config')

const entryPoint = path.join(__dirname, 'test', 'test.js')
const preprocessors = {
  [entryPoint]: ['webpack', 'sourcemap']
}

const webpackConf = webpackConfFunc()

module.exports = (config) => {
  config.set({
    browsers: ['ChromeForDocker'],
    customLaunchers: {
      ChromeForDocker: {
        base: 'ChromeHeadless',
        flags: ['--no-sandbox'],
      },
    },
    frameworks: ['jasmine'],
    files: [entryPoint],
    reporters: ['mocha'],
    preprocessors,
    webpack: {
      bail: true,
      mode: 'development',
      devtool: webpackConf.devtool,
      module: webpackConf.module,
      // todo plugins (DefinePlugin for example)
      resolve: webpackConf.resolve,
      target: webpackConf.target,
      plugins: [
        webpackConfFunc.ExtractCss,
      ],
      node: {
        process: false, // замокали process
      }
    },
    watch: false,
    singleRun: true,
  })
}
