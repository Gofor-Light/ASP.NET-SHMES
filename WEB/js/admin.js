
$(function() {    // 相当于在页面中的body标签加上onload事件
    $('.hide1').hide();
    $('.hide2').hide();
    $('.hide3').hide();
    $('.bt2').hide();
    $('.bt3').hide();
    $('.bt5').hide();

    
    $('#btn1').click(function() {   // 给页面的修改信息按钮加上click函数
    $('.hide1').show();
    $('.bt2').show();
    $('.bt1').hide();
    $('.wrong1 ul').hide()
    });
    
    $('#btn4').click(function() {   // 给页面的修改信息取消按钮加上click函数
    $('.hide2').hide();
    $('.hide1').hide();
    $('.bt2').hide();
    $('.bt1').show();
    $('.wrong1 ul').hide()
    });
    
    $('#btn2').click(function() {   // 给页面的修改密码按钮加上click函数
    $('.hide2').show();
    $('.bt3').show();
    $('.bt1').hide();
    $('.wrong1 ul').hide()
    });
  
    $('#btn6').click(function() {   // 给页面的修改密码取消按钮加上click函数
    $('.hide2').hide();
    $('.hide1').hide();
    $('.bt3').hide();
    $('.bt1').show();
    $('.wrong1 ul').hide()
    });  
    
    $('#btn7').click(function() {   // 给页面的新增管理员按钮加上click函数
    $('#btn7').hide();
    $('.hide3').show();
    $('.bt5').show();
    $('.wrong2 ul').hide()
    });
    
    $('#btn9').click(function() {   // 给页面的新增管理员取消按钮加上click函数
    $('#btn7').show();
    $('.hide3').hide();
    $('.bt5').hide();
    $('.wrong2 ul').hide()
    });
    
    $('input:checkbox:first').click(function() {   // 给页面的全选textbox添加click函数
    if($(this).attr("checked")) 
    $('input:checkbox:odd').attr("checked",true)
    else $('input:checkbox:odd').attr("checked",false)   
    });
    
   });
   
    /*
    $('#ctl00_ContentPlaceHolder1_txt3').focus(function (){
    $('#test').show();
    });
    
    $('#ctl00_ContentPlaceHolder1_TreeView1 a:not(a:has( img))').click(function() {   // 给页面的标签加上click函数
    $('#ctl00_ContentPlaceHolder1_txt3').attr("value",$(this).text());
    $('#test').hide();
    });
    
    $('.comment div:not(#ep1),#ep1 *:not(#ctl00_ContentPlaceHolder1_txt3)').click(function() {   // 给页面的标签加上click函数
    $('#test').hide();
    });
    
    $('#ctl00_ContentPlaceHolder1_TreeView1n0Nodes a ').mouseover(function() {  
    $(this).addClass('pre');
    });
    */

    