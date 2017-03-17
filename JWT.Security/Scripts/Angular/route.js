

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');

    $stateProvider
    .state('Home', {
        url: '/',       
        views: {
            'Header': {
                templateUrl: 'Home/Header',
               
            },
            'content': {
                templateUrl: 'Home/Home',
                controller: 'HomeController',
                controllerAs:"vm"
            }              
           

        }
    })

});