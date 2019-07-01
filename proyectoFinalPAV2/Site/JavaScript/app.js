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
    $scope.nuevoCliente = {};
    $scope.nuevoCliente.percepcionIIBB = 0;
    

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

    function obtenerTipoIIBB() {        
        if ($scope.tipoCliente.idTipoCliente != 1) {
            if ($scope.tipoConvenio.length == 0)
                $scope.obtenerTipoConvenioIIBB();
        }
    }

    $scope.tipoIIBBChange = function () {
        if (!$scope.nuevoCliente.percepcionIIBB) {
            $scope.nuevoCliente.idTipoConvenioIIBB = null;
        }
    }

    $scope.tipoConvenioComEInd = 0;
    $scope.nuevoCliente.percepcionComEInd = 0;

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

    function obtenerTipoConvenioComEInd() {
        if ($scope.tipoCliente.idTipoCliente != 1) {
            if ($scope.tipoConvenioComEInd.length == 0)
                $scope.obtenerTipoConvenioComEInd();
        }
    }

    $scope.tipoConvenioComEIndChange = function () {
        if (!$scope.nuevoCliente.percepcionComEInd) {
            $scope.nuevoCliente.idTipoConvenioComEInd = null;
        }
    }


    $scope.tipoClienteChange = function () {
        obtenerTipoIIBB();
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







