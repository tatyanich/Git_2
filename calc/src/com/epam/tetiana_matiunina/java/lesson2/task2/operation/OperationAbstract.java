package com.epam.tetiana_matiunina.java.lesson2.task2.operation;

/**
 * Created by Администратор on 21.10.2015.
 */
public abstract class OperationAbstract {

    private String operationName;

    public OperationAbstract(String operationName) {
        this.operationName = operationName;
    }

    public String getName() {
        return operationName;
    }

    public abstract double operate(double firstNumber, double secondNumber);

}
