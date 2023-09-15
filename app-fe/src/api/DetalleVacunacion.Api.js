import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const DetalleVacunacionApi = axios.create({
  baseURL: `${END_POINT_API}/DetalleVacunacion`,
  headers: {
    "Content-Type": "application/json",
    "x-access-token": getCookie(),
  },
});

export const get = async () => {
  const res = await DetalleVacunacionApi.get(`/Get`)
    .then((response) => {
      return response.data.records.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await DetalleVacunacionApi.post(`/Post`, data)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
