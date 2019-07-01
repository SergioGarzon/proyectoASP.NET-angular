var app = angular.module('crmClientes', []);
app.run(function ($rootScope) {
    $rootScope.server = 'http://localhost:57043/api/';
});
app.controller("busquedaClientesCtrl", function ($scope, $http) {
    $scope.lista = [];
    $scope.accionABMC = 'L';
    $scope.nombre = '';
    $scope.apellido = '';
    $scope.razonSocial = '';
    $scope.cuit = '';
    $scope.buscar = function () {
        $http({
            method: 'GET',
            url: $scope.server + 'Clientes?nombre=' + $scope.nombre + "&apellido=" + $scope.apellido + "&razonSocial=" + $scope.razonSocial + "&cuit=" + $scope.cuit
        }).then(function (res) {
            $scope.lista = res.data;
        }, function (err) {
            console.log(err);
            alert('Ocurrió un error');
        });
    };
    $scope.buscar();
});



app.controller("ctrlCargaCliente", function ($scope, $http) {
    $scope.tipos = [];
    $scope.accionABMC = 'L';
    $scope.tipoCliente = null;

    $scope.obtenerTipoCliente = function () {
        $http({
            method: 'GET',
            url: $scope.server + 'TipoClientes'
        }).then(function (res) {
            $scope.tipos = res.data;
            $scope.tipoCliente = $scope.tipos[0];
        }, function (err) {
            console.log(err);
            alert('Ocurrió un error');
        });
    };
    $scope.obtenerTipoCliente();

    
    $scope.tipoConvenio = [];
    $scope.accionABMC = 'L';

    $scope.obtenerTipoConvenioIIBB = function () {
        $http({
            method: 'GET',
            url: $scope.server + 'TipoConvenioIIBBs'
        }).then(function (res) {
            $scope.tipoConvenio = res.data;
        }, function (err) {
            console.log(err);
            alert('Ocurrió un error');
        });
    };

    $scope.onTipoClienteChange = function () {
        if ($scope.tipoCliente == 1) {
            //consumidor final
            
        } else {
            $scope.obtenerTipoConvenioIIBB();
        }
    }
    
    /*
    $scope.tipoConvenioComEInd = [];
    scope.accionABMC = 'L';

    $scope.obtenerTipoConvenioComEInd = function () {
        $http({
            method: 'GET',
            url: $scope.server + 'TipoConvenioComEInds'
        }).then(function (res) {
            $scope.tipoConvenioComEInd = res.data;
        }, function (err) {
            console.log(err);
            alert('Ocurrió un error');
        });
    };
    $scope.obtenerTipoConvenioComEInd();*/
});







