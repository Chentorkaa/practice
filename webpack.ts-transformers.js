// resolve https://github.com/Igorbek/typescript-plugin-styled-components#forked-process-configuration
// 1. import default from the plugin module
const tsImportPluginFactory = require('ts-import-plugin')

// 2. create a transformer;
// the factory additionally accepts an options object which described below
const tsImportPluginFactory1 = tsImportPluginFactory({
  libraryName: 'antd',
  libraryDirectory: 'lib',
  style: true,
});

// 3. create getCustomTransformer function
const getCustomTransformers = () => ({ before: [tsImportPluginFactory1] });

// 4. export getCustomTransformers
module.exports = getCustomTransformers;
