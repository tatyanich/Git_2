package com.epam.tetiana_matiunina.java.lesson2.task2.operation;

/**
 * Created by Tetiana_Matiunina on 26.10.2015.
 */
public enum MathOperationsEnum {
    sum("+"), subtract("-"), multiply("*"), divide("/");
    private final String mathOperations;

    public String toString() {
        return mathOperations;
    }

    private MathOperationsEnum(String mathOperations) {
        this.mathOperations = mathOperations;
    }
}
