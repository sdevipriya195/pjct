import React, { useEffect, useState } from "react";
import axios from "axios";
import './Movie.css';
import Popup from 'reactjs-popup';
import Rentals from "./Rentals";

function Movies() {
  const [movies, setMovies] = useState([]);
  const [movieName, setMovieName] = useState('');
  const [genreName, setGenreName] = useState('Action');
  const [isLoginOpen, setLoginOpen] = useState(false);

  const getMovies = () => {
    axios.get("http://localhost:5042/api/Movie", {
      params: {
        search: movieName,
        genre: genreName
      }
    })
      .then((response) => {
        
        setMovies(response.data);
      })
      .catch((err) => {
        setMovies([]);
        console.log(err);
        alert(err.response.data);
      });
  };


  const rent = () => {
    setLoginOpen(!isLoginOpen);
  };

  var hasMovies = movies.length > 0;

  return (
    <div className="center">
      <div>
        <input
          type="text"
          placeholder="Search by movie name"
          value={movieName}
          onChange={(e) => setMovieName(e.target.value)}
        />
        <select value={genreName} onChange={(e) => setGenreName(e.target.value)}>
          <option value="action">Action</option>
          <option value="comedy">Comedy</option>
          <option value="thriller">Thriller</option>
          <option value="romantic">Romantic</option>
          <option value="horror">Horror</option>
        </select>
        <button class="btn btn-primary" onClick={getMovies}>Search</button>
      </div>
      {hasMovies ? (
        <div>
          {movies.map((movie) => (
            <div className="card movie" key={movie.id}>
              <img className="card-img-top pic" src={movie.image} alt="Movie-Image" />
              <div className="card-body">
                <h5 className="card-title">Name:{movie.movieName}</h5>
                <p className="card-text">Genre:{movie.genreName}</p>
                <p className="card-text">Description:{movie.movieDescription}</p>
                <p className="card-text">Duration: {movie.movieDuration}</p>
                <p className="card-text">Rating: {movie.movieRating}</p>
                <p className="card-text">Cost: {movie.movieRentalCost}</p>
                <a className="btn btn-primary" onClick={rent}>
                  Rent It
                </a>
                <Popup open={isLoginOpen} closeOnDocumentClick onClose={rent}>
                  <Rentals movie={movie} />
                </Popup>
              </div>
            </div>
          ))}
        </div>
      ) : 
        <h6>No Movies</h6>
          }
    </div>
  );
}

export default Movies;
