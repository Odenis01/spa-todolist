(function () {
    'use strict';
    
    angular.module('appTodoList').config(function ($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController as vm',
                templateUrl: 'app/views/home/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            })
            .when('/home/afazer', {
                controller: 'HomeController as vm',
                templateUrl: 'app/views/home/index.html',
                resolve: {
                    action: function () { return 'afazer'; }
                }
            })
            .when('/home/feitos', {
                controller: 'HomeController as vm',
                templateUrl: 'app/views/home/index.html',
                resolve: {
                    action: function () { return 'feitos'; }
                }
            })
            .when('/tarefas', {
                controller: 'TarefaController as vm',
                templateUrl: 'app/views/tarefa/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            })            
            .when('/tarefas/:id', {
                controller: 'TarefaController as vm',
                templateUrl: 'app/views/tarefa/detalhes.html',
                resolve: {
                    action: function () { return 'details'; }
                }
            })
            .when('/categorias', {
                controller: 'CategoriaController as vm',
                templateUrl: 'app/views/categoria/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            })
            .when('/usuarios', {
                controller: 'UsuarioController as vm',
                templateUrl: 'app/views/usuario/index.html',
                resolve: {
                    action: function () { return 'list'; }
                }
            })            
    });

})();