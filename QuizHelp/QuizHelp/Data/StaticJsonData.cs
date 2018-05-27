using System;
namespace QuizHelp.Data
{
    public static class StaticJsonData
    {
        public static string GetQuestions() =>
        "{\r\n  \"questions\": [\r\n    {\r\n      \"title\": \"\u00BFDe qu\u00E9 presupuesto dispon\u00E9is?\",\r\n      \"answers\": [\r\n        {\r\n          \"title\": \"El m\u00EDnimo posible\",\r\n          \"image\": \"\",\r\n          \"result\": 0\r\n        },\r\n        {\r\n          \"title\": \"Pocos gastos\",\r\n          \"image\": \"\",\r\n          \"result\": 1\r\n        },\r\n        {\r\n          \"title\": \"Gasto medio\",\r\n          \"image\": \"\",\r\n          \"result\": 2\r\n        },\r\n        {\r\n          \"title\": \"Alto\",\r\n          \"image\": \"\",\r\n          \"result\": 3\r\n        }\r\n      ]\r\n    }\r\n  ],\r\n  \"results\": [\r\n    {\r\n      \"title\": \"\",\r\n      \"description\": \"\"\r\n    }\r\n  ]\r\n}";
    }
}
