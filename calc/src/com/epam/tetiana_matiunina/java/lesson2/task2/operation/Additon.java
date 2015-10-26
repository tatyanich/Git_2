package com.epam.tetiana_matiunina.java.lesson2.task2.operation;

/**
 * Created by Администратор on 21.10.2015.
 */
public class Additon extends OperationAbstract {


   public Additon() {
        super(MathOperationsEnum.sum.toString());
   }


    @Override
    public double operate(double firstNumber, double secondNumber) {
        return firstNumber + secondNumber;
    }
}
