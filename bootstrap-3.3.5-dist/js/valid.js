function checkPass()
{
   
            var pass = document.getElementById('Password');
            
            var passconf = document.getElementById('PasswordConfirm');
            
    
            var message = document.getElementById("confpass");
    
            var confColor = "#57ff71";
            var unconfColor = "#e83f3f";
            if(pass.value == passconf.value){
        
                passconf.style.borderColor = confColor;
                message.style.color = confColor;
                message.innerHTML = "Passwords Match!"
            }else{
                passconf.style.borderColor = unconfColor;
                message.style.color = unconfColor;
                message.innerHTML = "Passwords Do Not Match!"
                
                
    }
    
            
}  