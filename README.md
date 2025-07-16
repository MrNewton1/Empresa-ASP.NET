# Empresa – Cálculo de Sueldo Bruto por Hora

> **Práctica académica**  
> Este proyecto es desarrollado como parte de una práctica escolar para la comprensión y aplicación de conceptos de desarrollo web con ASP.NET Core Razor Pages, validación de formularios y diseño responsivo.

---

## 📋 Objetivos y Funcionalidades

Esta aplicación web tiene como propósito didáctico permitir a los estudiantes:

- Aplicar el modelo de páginas Razor en ASP.NET Core.
- Implementar validaciones tanto del lado del cliente como del servidor.
- Utilizar componentes de Bootstrap para el diseño de interfaces modernas.
- Comprender la lógica de cálculo de sueldo bruto, incluyendo el manejo de horas extra.

**Funcionalidades implementadas:**

- **Ingreso de horas trabajadas** (0–168 horas/semana)  
- **Ingreso de tarifa por hora** (decimal)  
- **Cálculo automático** de:
  - Sueldo base (hasta 40 h × tarifa normal)  
  - Horas extra (> 40 h)  
  - Tarifa de hora extra (tarifa normal × 1.10)  
  - Sueldo extra (horas extra × tarifa extra)  
  - Sueldo bruto total  
- **Validaciones** en cliente y servidor (.NET DataAnnotations + jQuery Unobtrusive Validation)  
- **Estilos** basados en Bootstrap 5 + CSS personalizado  
- **Navbar** con enlaces a “Inicio” y “Calcular Sueldo”  
- Plantilla de layout (`_Layout.cshtml`) con Subresource Integrity (SRI)

---

## 🛠 Tecnologías empleadas

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) (o superior)  
- ASP.NET Core Razor Pages  
- Bootstrap 5.3 (CDN o librerías locales con LibMan)  
- jQuery 3.6 + jQuery Validation  
- HTML5, CSS3  

---

## 🚀 Ejecución local (Guía para estudiantes)

1. **Clona el repositorio**  
   ```bash
   git clone https://github.com/tu-usuario/empresa.git
   cd empresa
   ```

2. **Restaura dependencias y compila**  
   ```bash
   dotnet restore
   dotnet build
   ```

3. **Ejecuta la aplicación**  
   ```bash
   dotnet run
   ```

4. Abre tu navegador en `https://localhost:5001` (o la URL que muestre la consola).  
   - **Inicio**: página de bienvenida con enlace al formulario.  
   - **Calcular Sueldo**: directamente `/CalcularSueldo`.

---

## 🔍 Estructura académica del proyecto

```text
Empresa/
├─ Pages/
│  ├─ Shared/
│  │  └─ _Layout.cshtml          ← Layout principal con navbar y scripts
│  ├─ Index.cshtml               ← Página de bienvenida
│  ├─ Index.cshtml.cs
│  ├─ CalcularSueldo.cshtml      ← Formulario de cálculo
│  └─ CalcularSueldo.cshtml.cs   ← Lógica de cálculo en OnPost()
├─ wwwroot/
│  ├─ css/
│  │  └─ site.css                ← Estilos personalizados
│  └─ lib/                       ← (opcional) librerías Bootstrap, jQuery, etc.
├─ appsettings.json
└─ Empresa.csproj
```

Cada archivo y carpeta está estructurado para facilitar el aprendizaje y la comprensión de los conceptos fundamentales de ASP.NET Core y desarrollo web moderno.

---

## 🎨 Personalización de estilos

- Edita `wwwroot/css/site.css` para ajustar colores, tipografías y sombras.  
- Para usar Sass/SCSS, instala un bundler (LibSass, WebCompiler) y renombra tus archivos a `.scss`.  
- Si prefieres librerías locales en lugar de CDN, usa [LibMan](https://docs.microsoft.com/aspnet/core/client-side/libman) para traer:  
  ```bash
  libman install twitter-bootstrap@5.3.2 -d wwwroot/lib/bootstrap
  libman install jquery@3.6.0 -d wwwroot/lib/jquery
  libman install jquery-validation@1.19.5 -d wwwroot/lib/jquery-validation
  libman install jquery-validation-unobtrusive@3.2.12 -d wwwroot/lib/jquery-validation-unobtrusive
  ```

---

## ✅ Pruebas unitarias (Enfoque académico)

Para reforzar el aprendizaje sobre pruebas automatizadas, se sugiere crear pruebas unitarias para la lógica de cálculo:

1. Crea un proyecto `xUnit` en la solución:
   ```bash
   dotnet new xunit -n Empresa.Tests
   dotnet sln add Empresa.Tests/Empresa.Tests.csproj
   ```
2. Agrega referencia al proyecto principal:
   ```bash
   dotnet add Empresa.Tests/Empresa.Tests.csproj reference Empresa/Empresa.csproj
   ```
3. Escribe pruebas para `CalcularSueldoModel.OnPost()`, validando casos:
   - ≤ 40 h  
   - > 40 h  

---

## 🤝 Contribuir (Práctica colaborativa)

Las contribuciones son bienvenidas como parte de la dinámica de trabajo en equipo y aprendizaje colaborativo:

1. Haz un _fork_ del repositorio.  
2. Crea una rama (`git checkout -b feature/miprimera`).  
3. Haz _commit_ de tus cambios (`git commit -am 'Agrega X funcionalidad'`).  
4. Envía un _pull request_.

---

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

> **Nota académica:**  
> El uso de este código está orientado a fines educativos y de aprendizaje en el contexto de prácticas escolares.
