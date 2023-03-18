1. Install the LivingDoc CLI as a global dotnet tool.

``` batch
dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
```

2. Navigate to the **output directory of the SpecFlow project**. In this example the solution was setup in the `bin` folder.

``` batch
\bin\Debug\net7.0
```

3. Run the LivingDoc CLI by using the below command to generate the HTML report.

``` batch
livingdoc test-assembly John.SpecFlow.Test.dll -t TestExecution.json
```

4. Open the generated HTML with your favorite browser. The HTML file is stored in the same folder as the **output directory of the SpecFlow project**.

``` batch
\bin\Debug\net7.0\LivingDoc.html
```
