package com.epam.tetiana_matiunina.java.lesson2.task2.operation;

/**
 * Created by Tetiana on 21.10.2015.
 */
public class Subtraction extends OperationAbstract {


    public Subtraction() {
        super(MathOperationsEnum.subtract.toString());
    }


    @Override
    public double operate(double firstNumber, double secondNumber) {
        return firstNumber-secondNumber;
    }
}
