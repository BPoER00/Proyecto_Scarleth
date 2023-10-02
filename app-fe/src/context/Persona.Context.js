"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get, post, getSP } from "@/api/Persona.Api";
import { get as getDetalleVacunacion } from "@/api/DetalleVacunacion.Api";
import { get as getDireccion } from "@/api/Direccion.Api";
import { get as getGenero } from "@/api/Genero.Api";

const PersonaContext = createContext();

export const usePersona = () => {
  const context = useContext(PersonaContext);
  if (!context) throw new Error("usePersona must used within a provider");
  return context;
};

function PersonaProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Persona", status: "this" },
    { id: 2, name: "Nuevas Persona", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);
  const [persona, setPersona] = useState();
  const [direccion, setDireccion] = useState();
  const [genero, setGenero] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  useEffect(() => {
    getSP().then((data) =>
      setPersona(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    getDireccion().then((data) =>
      setDireccion(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    getGenero().then((data) =>
      setGenero(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const Persona = async (pagina, filtros) => {
    const persona = await get(pagina, filtros)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return persona;
  };

  const Vacunacion = async (pagina, personaId) => {
    const vacunacion = await getDetalleVacunacion(pagina, personaId)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacunacion;
  };

  const insert = async (credentials) =>
    post({
      nombre: credentials.nombre,
      cui: `${credentials.cui}`,
      telefono: `${credentials.telefono}`,
      fecha_nacimiento: credentials.fecha_nacimiento,
      direccion_id: credentials.direccion_id,
      genero_id: credentials.genero_id,
    });

  return (
    <PersonaContext.Provider
      value={{
        Vacunacion,
        persona,
        insert,
        direccion,
        genero,
        Persona,
        paginate,
        changePage,
      }}
    >
      {children}
    </PersonaContext.Provider>
  );
}

export default PersonaProvider;
