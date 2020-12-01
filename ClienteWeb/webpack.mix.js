let mix = require('laravel-mix');
const TargetsPlugin = require('targets-webpack-plugin');
const CompressionPlugin = require('compression-webpack-plugin');
mix.js('src/app.js', '').extract();

mix.webpackConfig(webpack => {
    return {
        plugins: [
            new webpack.ProvidePlugin({
                $: 'jquery',
                jQuery: 'jquery',
                'window.jQuery': 'jquery',
                'Popper': 'popper.js'
            }), new webpack.ProvidePlugin({
                AOS: 'aos',
                'window.AOS': 'aos',
            }),
            new CompressionPlugin({
                test: /\.js(\?.*)?$/i,
            })
            ,new TargetsPlugin({
             browsers:['last 2 versions', 'chrome >=41','IE 10'],
            })
        ]
    };
});

mix.webpackConfig({
    output: {
        filename: '[name].js',
        chunkFilename: 'js/[name].js',
        publicPath: './'
    }
});
mix.babelConfig({
    plugins: ['@babel/plugin-syntax-dynamic-import'],
});