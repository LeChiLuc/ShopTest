/// <reference path="/Assets/Admin/libs/angular/angular.js" />

(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$ịnject = ['$scope', 'apiService'];

    function productCategoryListController($scope,apiService) {
        $scope.productCategories = [];

        $scope.getProductCategories = getProductCategories;

        function getProductCategories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Load productcategory failed.');
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('shoptest.product_categories'));