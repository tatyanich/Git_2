package com.epam.tetiana_matiunina.java.lesson2.task2;

/**
 * Created by Tetiana on 21.10.2015.
 */
public class Parser {

    public static String[] parseExpression(String expressionString) {

        String[] arraySymbolsAndNumbers = expressionString.replaceAll("\\s+", "").trim().split("(?<=[-+*/])|(?=[-+*/])");
        return arraySymbolsAndNumbers;
    }
}
