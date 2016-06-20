(function () {
    'use strict';    
    angular.module('appTodoList.directives', []);
    angular.module('appTodoList', ['ngAnimate', 'ngRoute', 'appTodoList.directives']);

    angular.module('appTodoList').constant('APP_SETTINGS', {
        "VERSION": "0.0.1",
        "SERVICE_URL": "http://localhost:50075/"
    });
    
})();