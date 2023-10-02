import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const DashboardApi = axios.create({
  baseURL: `${END_POINT_API}/Dashboard`,
  headers: {
    "Content-Type": "application/json",
    Authorization: getCookie(),
  },
});

export const getCuadros = async () => {
  const res = await DashboardApi.get("Get/Cuadros")
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const getGrafica1 = async () => {
  const res = await DashboardApi.get("Get/Grafica/1")
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};

export const getGrafica2 = async () => {
  const res = await DashboardApi.get("Get/Grafica/2")
    .then((response) => {
      return response.data.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
