const { createProxyMiddleware } = require('http-proxy-middleware');

module.exports = function(app) {
  
    app.use(
        '/forecast',
        createProxyMiddleware({
            target          : 'http://localhost:8083/query',
            pathRewrite     : { "^/forecast" : "" },
            changeOrigin    : false,
            secure          : false
        })
    );

    app.use(
        '/state',
        createProxyMiddleware({
            target          : 'http://localhost:8082',
            pathRewrite     : { 
                "^/state/ac" : "http://localhost:8082/Acre",
                "^/state/sp" : "http://localhost:8082/SaoPaulo",
                "^/state/to" : "http://localhost:8082/Tocantins"
             },
            changeOrigin    : false,
            secure          : false
        })
    );

    app.use(
        '/auth',
        createProxyMiddleware({
            target          : 'http://localhost:8081',
            pathRewrite     : { "^/auth" : "http://localhost:8081/auth" },
            changeOrigin    : false,
            secure          : false
        })
    );

};