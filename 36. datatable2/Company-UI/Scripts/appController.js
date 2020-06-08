
var app = angular.module("myApp", []);
app.controller("mainController", function ($scope, $http, $location) {
    //debugger;
    

    // countries list
    $http.get('/Home/GetCountriesList')
        .then(function (response) {
            $scope.countries = response.data;
        });

    // Load Emploee List
    $scope.loadData = function () {
        // Employee list
        $http.get('/Home/GetEmpList')
            .then(function (response) {
                $scope.employeeList = response.data;
            });
    }
    $scope.loadData();
    // Delete 
    $scope.delete = function (index, id) {
        //console.log(index + " : " + id);
        if (confirm('Are you sure you want to delete?')) {
            //var item = $scope.employeeList[index];
            //console.log(item.id);
            $http.post('/Home/DeleteEmp/' + id)
            .then(function (response) {
                $scope.loadData();
            });
        }
    }
    // Edit    
    $scope.edit = function () {         
        var item = {            
            id: $scope.id,
            age: $scope.age,
            name: $scope.name,
            email: $scope.email,
            countryId: $scope.countryId,
            
        };
        
        $http.post('/Home/Edit', $.param(item), { headers: { 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;' } })
            .then(function (response) {                                
                $scope.loadData();

                $scope.id = '';
                $scope.age = '';
                $scope.name = '';
                $scope.email = '';
                $scope.country = '';
            });


    }
    // show edit    
    $scope.showEdit = function (id) {
        $http.get('/Home/GetEmpById/' + id)
            .then(function (response) {
                var item = response.data;
                //console.log(response.data.id)
                $scope.id = item.id;                
                $scope.age = item.age;
                $scope.name = item.name;
                $scope.email = item.email;
                $scope.country = item.country;
                $scope.countryId = item.countryId;
                console.log(item.countryId + "c " + item.country)
            });
    }
    // add
    $scope.add = function () {
        
        var item = {
            id: $scope.id,
            age: $scope.age,
            name: $scope.name,
            email: $scope.email,
            countryId: $scope.countryId,
        };

        $http.put('/Home/AddEmp', $.param(item), { headers: { 'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;' } })
            .then(function (response) {
                $scope.loadData();

                $scope.id = '';
                $scope.age = '';
                $scope.name = '';
                $scope.email = '';
                $scope.country = '';
            });


    }

});

