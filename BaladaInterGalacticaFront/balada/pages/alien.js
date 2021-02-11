import {useState, useEffect} from "react";
import React from 'react';
import Menu from '../styles/component/menu.js'

export default function  Alien() {
  const [name, setName] = useState(null);
  const [dateOfBirth, setDateOfBirth] = useState(null);
  const [banned, setBanned] = useState(false);
 

  console.log(name, dateOfBirth, banned);

  function cadastrarAlien() {
  var model = { 
    name: name,
    dateOfBirth: dateOfBirth,
    banned: banned
  }
    fetch('https://localhost:5001/api/alien',{ method: 'POST', body: JSON.stringify(model), headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'}
    })
    .then(respond => {
      if(!respond.ok){
        throw Error(respond.statusText);
      }
      return respond;
    })
    .catch(e => console.log('Erro: verifique os campos ', e))
  
  }

  return (
    <div>
    <Menu/>
      <form>
        <center>
        <h2>Nome</h2><br/>
        <input type="text" name="name" onChange={e =>  setName(e.target.value)}/><br/>
        <h2>Data de Nascimento</h2><br/>
        <input type="datetime-local" onChange={e => setDateOfBirth(e.target.value)}/><br/>
        <h2>Banido</h2><br/>
        <input type="checkbox" name='checked' onChange={e =>  setBanned(e.target.checked)}/><br/>
        <button onClick={(evento) => {
          evento.preventDefault()
          cadastrarAlien()
        }
        }>Cadastrar</button>
        </center>
      </form>
      </div>
  )
  
}


