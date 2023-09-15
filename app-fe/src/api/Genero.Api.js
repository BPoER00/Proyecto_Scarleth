import axios from "axios";
import { END_POINT_API } from "@/config/props.js";
import { getCookie } from "@/config/cookieConfig.js";

const GeneroApi = axios.create({
  baseURL: `${END_POINT_API}/Genero`,
  headers: {
    "Content-Type": "application/json",
    "x-access-token": getCookie(),
  },
});

export const get = async () => {
  const res = await GeneroApi.get(`/Get`)
    .then((response) => {
      return response.data.records.data;
    })
    .catch((error) => {
      return error.response;
    });

  return res;
};
