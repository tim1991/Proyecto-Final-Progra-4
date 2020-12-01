let mix = require('laravel-mix');
const TargetsPlugin = require('targets-webpack-plugin');
mix.sass('src/app.scss', 'css');

mix.webpackConfig(webpack => {
    return {
        plugins: [
            new webpack.ProvidePlugin({
                $: 'jquery',
                jQuery: 'jquery',
                'window.jQuery': 'jquery',
            })
            ,new webpack.ProvidePlugin({
                AOS: 'aos',
                'window.AOS': 'aos',
            })
            ,new TargetsPlugin({
                browsers:['last 2 versions', 'chrome >=41','IE 10'],
             })
        ]
    };
});