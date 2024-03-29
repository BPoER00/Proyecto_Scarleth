"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { post as postDetalleVacunacion } from "@/api/DetalleVacunacion.Api";
import { get, post } from "@/api/Vacunacion.Api";
import { getSP as getAsignacion } from "@/api/Asignacion.Api";
import { getSP as getVacuna } from "@/api/Vacuna.Api";
import { getSP as getPersona } from "@/api/Persona.Api";

const VacunacionContext = createContext();

export const useVacunacion = () => {
  const context = useContext(VacunacionContext);
  if (!context) throw new Error("useVacunacion must used within a provider");
  return context;
};

function VacunacionProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Vacuna", status: "this" },
    { id: 2, name: "Nuevas Vacuna", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);
  const [asignacion, setAsignacion] = useState();
  const [vacuna, setVacuna] = useState();
  const [persona, setPersona] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  useEffect(() => {
    getAsignacion().then((data) =>
      setAsignacion(data.map((m) => ({ value: m.id, label: m.persona.nombre })))
    );
    getVacuna().then((data) =>
      setVacuna(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    getPersona().then((data) =>
      setPersona(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const Vacunacion = async (pagina, filtro) => {
    const vacunacion = await get(pagina, filtro)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacunacion;
  };

  const insert = async (credentials) => post(credentials);

  const insertDetalleVacunacion = async (credentials) =>
    postDetalleVacunacion(credentials);

  return (
    <VacunacionContext.Provider
      value={{
        insertDetalleVacunacion,
        insert,
        asignacion,
        vacuna,
        persona,
        Vacunacion,
        paginate,
        changePage,
      }}
    >
      {children}
    </VacunacionContext.Provider>
  );
}

export default VacunacionProvider;
