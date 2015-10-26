package com.epam.tetiana_matiunina.java.lesson2.task2;

import com.epam.tetiana_matiunina.java.lesson2.task2.operation.*;

import java.util.Scanner;

/**
 * Created by Tetiana_Matiunina on 26.10.2015.
 */
public class Demo {
    private static Calculator calculator;
    public static void init(){
        calculator = new Calculator();
        calculator.addOperation(new Additon());
        calculator.divideOperation(new Division());
        calculator.multiplyOperation(new Multiplication());
        calculator.subtractOperation(new Subtraction());
    }
    public static void main(String [] args){
        System.out.println("Please enter math expression:");
        String expressionString = new Scanner(System.in).nextLine();

        String errorOfInput = Validator.validate(Parser.parseExpression(expressionString));
        if(!errorOfInput.equals("")){
            System.out.println(errorOfInput);
        }
        else{
            init();
            String [] array = Parser.parseExpression(expressionString);
            try{
            double first = Double.valueOf(array[0]);
            double second = Double.valueOf(array[2]);
            System.out.println(calculator.calculate(array[1], first, second));
            }catch (Exception e ){
                System.out.println("Operand is invalid");
            }



        }

    }

}


