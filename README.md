Pasos para iniciar el proyecto:

1. Se debe tener listo una base de datos de MySql.
2. Debe configurar la cadena de conexión en los archivos appsettings de las apis.
3. Debe condifurar la cadena de conexión en el archivo DemoKafkaContextFactory.cs.
4. Debe impactar las migraciones en la base de datos con el siguiente comando:
  Update-Database -p DemoKafka.PersistenceEFCore -s DemoKafka.PersistenceEFCore -context DemoKafkaContextFactory
5. Debe levantar kafka con docker compose situandose en la carpeta del archivo kafka-brokers.yml, luego ejecuta el siguiente comando:
   docker-compose -f kafka-brokers.yml up
6. Finalmente ya puede realizar pruebas con el proyecto conectado a Kafka.
7. El proyecto registra una orden de compra, producto del registro se envia una notificación a kafka, que posteriormente
   será consumido por un servicio que obtiene el mensaje y lo guarda en la base de datos.
