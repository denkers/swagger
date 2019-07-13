    public static class SwaggerExtension
    {
        public static IServiceCollection AddSwaggerExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Invoicing API",
                    Description = "Web Api responsable de gestión de facturas desde SAP",
                    TermsOfService = "(1) La información de las facturas se obtienen en línea (2) Si se consulta por cliente, solo se muestran las facturas pendientes",
                    Contact = new Contact
                    {
                        Name = "Customer Service",
                        Email = "servicioalcliente@satrack.com",
                        Url = "https://www.satrack.com.co/contactanos/"
                    }
                });

                //Pendiente adicionar seguridad con keycloak
                //c.AddSecurityDefinition("Bearer", new OAuth2Scheme
                //{
                //    Type = "oauth2",
                //    Flow = "application",
                //    TokenUrl = $"http://{configuration["Authentication:IdentityServer"]}/auth/realms/satrack-base/protocol/openid-connect/token"
                //});

                //var security = new Dictionary<string, IEnumerable<string>> {
                //     { "Bearer",new string [] { } }
                // };
                //c.AddSecurityRequirement(security);

                ///Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
