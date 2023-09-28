import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const VacunaApi = axios.create({
  baseURL: `${END_POINT_API}/Vacunas`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const get = async (pagina) => {
  const res = await VacunaApi.get(`/Get?pagina=${pagina}`)
    .then((response) => {
      return response.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const getSP = async () => {
  const res = await VacunaApi.get(`/GetSP`)
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const post = async (data) => {
  const res = await VacunaApi.post(`/Post`, data)
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
