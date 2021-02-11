import {useState, useEffect} from "react";
import Menu from '../styles/component/menu.js'


export default function CheckIn() {
  const [idAlien, setIdAlien] = useState(null);
  const [idBallad, setIdBallad] = useState(null);
  const [idObjectNotAllowed, setIdObjectNotAllowed] = useState(null);

  const [aliens, setAliens] = useState([{id: 0, name: 'Selecione um alien'}]);
  const [ballads, setIdBallads] = useState([{id: 0, name: 'Selecione uma balada'}]);
  const [objectNotAlloweds, setIdObjectNotAlloweds] = useState([{id: null, name: 'Verifique os Objeto Proibido'}]);

  function registerCheckIn() {
    console.log(`${idAlien} - ${idBallad} - ${idObjectNotAllowed}`);

    var model = {  
      idAlien: idAlien,
      idBallad: idBallad,
      idObjectNotAllowed: idObjectNotAllowed
  
    }
  
      fetch('https://localhost:5001/api/CheckInCheckOut',{ method: 'POST', body: JSON.stringify(model), headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'}
      })
      .then(respond => {
        if(!respond.ok){
          throw Error(respond.statusText);
        }
        return respond
      })
      .catch(e => alert('Erro: Verifique os campos do Chek In', e))   
     
  }

  useEffect(
   async () => {
     var result = await fetch('https://localhost:5001/api/Alien',{ method: 'GET', headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'}
      })

      var data = await result.json();
      var listAliens = [
        {id: 0, name: 'Selecione um alien'},
        ...data
      ];
      
      setAliens(listAliens);
    },[]
  ) 

  
  useEffect(
    async () => {
      var result = await fetch('https://localhost:5001/api/Ballad',{ method: 'GET', headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'}
       })
 
       var data = await result.json();
       var listBallads = [
         {id: 0, name: 'Selecione uma Balada'},
         ...data
       ];
       
       setIdBallads(listBallads);
     },[]
   ) 

   useEffect(
    async () => {
      var result = await fetch('https://localhost:5001/api/ObjectNotAllowed',{ method: 'GET', headers: {
         'Accept': 'application/json',
         'Content-Type': 'application/json'}
       })
 
       var data = await result.json();
       var listObjectNorAlloweds = [
         {id: null, name: 'Verifique os Objetos Proibidos'},
         ...data
       ];
       
       setIdObjectNotAlloweds(listObjectNorAlloweds);
     },[]
   ) 

  function Alien(all) {
    setIdAlien(all);
  }
  function Ballad(all) {
    setIdBallad(all);
  }
  function ObjectNotAllowed(all) {
    setIdObjectNotAllowed(all);
  } 

  return (
    <div>
      <Menu/>
      <form>
        <center>
            <h2>Nome do Alien</h2><br/>
            <select onChange={event => Alien(event.target.value)}> 
              {
                aliens.map(
                  (item, index) =>  <option key={index} value={item.id}>{item.name}</option>
                )
              }
            </select>
            <h2>Balada</h2><br/>
            <select onChange={event => Ballad(event.target.value)}> 
              {
                ballads.map( 
                  (item, index) =>  <option key={index} value={item.id}>{item.name}</option>
                )
              }
            </select>
            <h2>Objetos Proibidos</h2><br/>
            <select onChange={event => ObjectNotAllowed(event.target.value)}> 
              {
                objectNotAlloweds.map(
                  (item, index) =>  <option key={index} value={item.id}>{item.name}</option>
                )
              }
            </select><br/>
            <button onClick={(evento) => {
              evento.preventDefault()
              registerCheckIn()
              }}>Check In</button>
        </center>
      </form>
      </div>
  )
}
