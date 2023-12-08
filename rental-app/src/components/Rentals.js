import axios from "axios";
import { useEffect, useState } from "react";
import './Rental.css';
import { Link } from "react-router-dom";

function Rentals({ movie }) {
  const [id, setId] = useState(movie.movieId);
  const [date, setDate] = useState("");
  const [cost, setCost] = useState(movie.movieRentalCost);

  const rent = (event) => {
    event.preventDefault();
    console.log(id);
    console.log(date);
    console.log(cost);
    axios.post('http://localhost:5042/api/Rental', {
      rentalDate: date,
      rentalCost: cost,
      movieId: id
    })
      .then((response) => {
        alert("added");
        console.log(response.data);
      })
      .catch((err) => {
        console.log(err);
        alert("error");
      })
  }

  return (
    <div className="center card">
      <form>
        <input id="pcheckOut" required type="text" className="form-control input" placeholder="Check-Out" value={date} onChange={(e) => { setDate(e.target.value) }} />
        <h6>Price:</h6> <input type="text" className="form-control" placeholder="price" value={cost} disabled />
        <button type="button" className="btn btn-success" onClick={rent}>Rent It</button>
      </form>
    </div>
  )
}

export default Rentals;
 