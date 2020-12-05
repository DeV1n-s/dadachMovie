module.exports = {
    "transpileDependencies": [
        "vuetify"
    ],
    devServer: {
        proxy: 'https://localhost:5001/',
    }
}