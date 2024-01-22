Detalles

[Carpetas]

' 01Comun ': "Almacena el contenido necesario correspondiente a recursos comúnes, que serán utilizados desde todas las capas (por ej. ViewModels, utilitarios, funciones para encriptar/moduladas, etc)" -' capa ' refiere a cada instancia, o bien carpeta, que se complementa en la construcción de la solución-
' 02Modelo ': "Una vez creado el modelo en la DB, acá se registran las entidades pertinentes, el contexto, metadatos, validadores, entre otros"
' 03AccesoDatos ': "Contiene repositorios para hacer consultas a la DB, inserciones, actualizaciones..."
' 04ClienteRest ': "Registra lo necesario para implementar el consumo de servicios REST"
' 05LogicaDeNegocio ': "Provee la lógica de validación, accesos, así como para abstraer la comunicación entre la capa de presentación (' WebAPI ') y el resto"