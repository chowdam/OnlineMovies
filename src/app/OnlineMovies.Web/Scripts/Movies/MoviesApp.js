//(function () {

//    var app = angular.module("MoviesApp", []);

//    app.controller("HomeCtrl", function ($scope) {
//        $scope.Message = "Guest!";
//    });

//})();

var moviesAppModule = angular.module("moviesAppModule", []);
moviesAppModule.controller("HomeCtrl", function ($scope) {
        $scope.Message = "Guest!";
    });