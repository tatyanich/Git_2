package com.epam.tetiana_matiunina.java.lesson2.task2.operation;

/**
 * Created by Tetiana Matiunina on 21.10.2015.
 */
public class Division extends OperationAbstract {


    public Division() {
        super(MathOperationsEnum.divide.toString());
    }

    @Override
    public double operate(double firstNumber, double secondNumber)throws ArithmeticException{

        if(secondNumber==0){
            throw new  ArithmeticException("Divided by zero is impossible");
        }
       else {

            return firstNumber / secondNumber;
        }
    }


}
