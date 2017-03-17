angular.module('ApplicationModule').factory('sessionInjector', function () {
    var sessionInjector = {
        request: function (config) {
            config.headers['x-session-token'] = 'Ahmar';
            return config;
        }
    };
    return sessionInjector;
});


angular.module('ApplicationModule').config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('sessionInjector');      
}]);