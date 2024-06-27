# **API gestión clientes - TEST**

API que permite la gestión de clientes, contando con seguridad a través de generación de token (JWT).

## **Contenido**

1. [Notas de la Versión](https://github.com/CrLara88/ClientesAPI/tree/main#notas-de-la-versi%C3%B3n)
2. [Requerimientos](https://github.com/CrLara88/ClientesAPI/tree/main#requerimientos)
3. [Documentación](https://github.com/CrLara88/ClientesAPI/tree/main#documentaci%C3%B3n)
4. [Pruebas sobre la API](https://github.com/CrLara88/ClientesAPI/tree/main#pruebas-sobre-la-api)

## **Notas de la Versión**

Esta versión implementa 4 Endpoints:

- **Método VALIDAR**: Permite la validación del usuario en base a su correo y contraseña. 
Si la validación es exitosa, genera un token que permite consumir de forma correcta el 
resto de endpoints.

- **Método CREATECLIENT**: Permite la creación de un nuevo cliente.

- **Método UPDATECLIENTBYID**: Permite actualizar un cliente en base a su ID.

- **Método GETCLIENTBYID**: Permite la recuperación de un cliente por su respectivo ID.

## **Requerimientos**
- .NET Core 7.0 o superior.

## **Documentación**
- Documentación disponible a través de Swagger, luego de obtener, compilar y ejecutar el proyecto.

## **Pruebas sobre la API**
- Para generar el token de manera inicial, se debe usar cualquiera de estas 2 credenciales de los clientes existentes en la base de datos:
  1. Email: test@gmail.com - Password: 12345678
  2. Email: user@example.com - Password: hello4321
- Para autenticar con email y password, se puede usar la de cualquier cliente existente en la base de datos. Esto en caso de crear nuevos clientes.
- Para realizar consultas con el Endpoint "GETCLIENTBYID", se puede utilizar los usuarios ya existentes con el IdClient 1 o 2.
