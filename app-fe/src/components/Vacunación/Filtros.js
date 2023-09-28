import React, { useEffect } from "react";
import InputText from "../Inputs/InputText";
import InputSelect from "../Inputs/InputSelect";
import { useForm } from "react-hook-form";
import { useVacunacion } from "@/context/Vacunacion.Context";

function Filtros({ setFiltros }) {
  const { vacuna, persona } = useVacunacion();

  const {
    register,
    control,
    watch,
  } = useForm();

  const personaId = watch("persona_id");
  const fechaInicioValue = watch("fecha_vacunacion_inicio");
  const fechaFinValue = watch("fecha_vacunacion_fin");
  const vacunaId = watch("vacuna_id");

  useEffect(() => {
    const filtros = {
      personaId,
      fechaInicioValue,
      fechaFinValue,
      vacunaId,
    };

    setFiltros(filtros);
  }, [personaId, fechaInicioValue, fechaFinValue, vacunaId]);

  return (
    <div className="px-8 pt-6 pb-4 mb-1 dark:bg-gray-800 rounded">
      <div className="flex flex-wrap -mx-4">
        <div className="w-1/4 px-4 mb-4">
          <InputSelect
            label={"Persona"}
            name={"persona_id"}
            options={persona}
            control={control}
            placeholder={"Persona..."}
          />
        </div>
        <div className="w-1/4 px-4 mb-4">
          <InputText
            label={"Inicio"}
            name={"fecha_vacunacion_inicio"}
            type={"date"}
            placeholder={"Ingrese Fecha Vacunacion..."}
            register={register}
          />
        </div>
        <div className="w-1/4 px-4 mb-4">
          <InputText
            label={"Fin"}
            name={"fecha_vacunacion_fin"}
            type={"date"}
            placeholder={"Ingrese Fecha Vacunacion..."}
            register={register}
          />
        </div>
        <div className="w-1/4 px-4 mb-4">
          <InputSelect
            label={"Vacuna"}
            name={"vacuna_id"}
            options={vacuna}
            control={control}
            placeholder={"Vacuna..."}
          />
        </div>
      </div>
    </div>
  );
}

export default Filtros;
