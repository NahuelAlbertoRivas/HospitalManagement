**It's recommended to look at both the ' Entity-Relationship Diagram ' (DER/ERD) and the ' Relational Model ' (MR/RM) for a greater understanding of the project**

Details

[Folders]

' 01Comun ': "Almacena el contenido necesario correspondiente a recursos comúnes, que serán utilizados desde todas las capas (por ej. ViewModels, utilitarios, funciones para encriptar/moduladas, etc)" -' capa ' refiere a cada instancia, o bien carpeta, que se complementa en la construcción de la solución-
' 02Modelo ': "Una vez creado el modelo en la DB, acá se registran las entidades pertinentes, el contexto, metadatos, validadores, entre otros"
' 03AccesoDatos ': "Contiene repositorios para hacer consultas a la DB, inserciones, actualizaciones..."
' 04ClienteRest ': "Registra lo necesario para implementar el consumo de servicios REST"
' 05LogicaDeNegocio ': "Provee la lógica de validación, accesos, así como para abstraer la comunicación entre la capa de presentación (' WebAPI ') y el resto"

[Frontend]

-> src
	-> config: archivos de configuración general
	-> directives: directivas
	-> guards: seguridad/acceso a cada uno de los módulos
	-> interceptors: servicio que intercepta peticiones y respuestas HTTP generadas por el cliente HTTP integrado de Angular
	-> modules: módulos
	-> pipes: funciones simples que reciben un valor y retornan otro transformado
	-> services: implementación de los cinco servicios establecidos
	-> validators: validadores a aplicar sobre los campos que recuperarán info. a registrar en cada una de las entidades

Referencias

VMR: View Model Resources
DAL: Data Access Layer
BLL: Business Logic Layer