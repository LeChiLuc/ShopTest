/// <reference path="/Assets/Admin/libs/angular/angular.js" />

(function () {
    angular.module('shoptest',
        ['shoptest.products',
         'shoptest.product_categories',
         'shoptest.common'])
        .config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller:"homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();