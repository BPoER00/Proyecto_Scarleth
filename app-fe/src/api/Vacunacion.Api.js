import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";
import { Frijole } from "next/font/google";

const VacunacionApi = axios.create({
  baseURL: `${END_POINT_API}/Vacunacion`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina, filtro) => {
  const res = await VacunacionApi.get(`/Get?pagina=${pagina}&filtro=${filtro}`)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await VacunacionApi.post(`/Post`, data)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
