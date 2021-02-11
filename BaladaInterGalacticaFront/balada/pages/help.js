import React from 'react';
import Menu from '../styles/component/menu.js'

export default function  Help() {

  return (
    <div>
    <Menu/>
      <form>
        <center>
        <h2>Alien</h2><br/>
        <h3>Digite o nome do alien no campo e aperte o botão cadastrar</h3>
        <h2>Balada</h2><br/>
        <h3>Digite o nome da balada no campo e aperte o botão cadastrar</h3>
        <h2>Objeto Proibido</h2><br/>
        <h3>Digite o nome do Objeto a ser proibido e aperte o botão cadastrar</h3>
        <h2>Check in e Check out</h2><br/>
        <h3>Para fazer o check in preencha os campos obrigatórios nome do alien, nome da balada e verifique os objetos proibidos. 
            Para fazer check out escolha o check out que deseja fazer.</h3>
        </center>
      </form>
      </div>
  )
  
}
