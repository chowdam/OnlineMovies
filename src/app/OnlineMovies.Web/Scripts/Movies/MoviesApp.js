(function () {

    var app = angular.module("MoviesApp", []);

    app.controller("MoviesHomeCtrl", function ($scope) {
        $scope.Message = "Guest!"
    });

})();