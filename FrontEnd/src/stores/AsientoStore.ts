// AsientoStore.ts
import { defineStore } from 'pinia';
import { ref } from 'vue';

interface Asiento {
  obraId: number;
  asientoId: number;
  reservado: boolean;
  num_Asiento: number;
}

interface Seat {
  asientoId: number;
  num_Asiento: number;
}

export const useAsientoStore = defineStore('asientoStore', () => {
  const seats = ref<Asiento[]>([]);
  const choosenSeats = ref<Seat[]>([]);

  // Función para cargar asientos (simulada)
  async function cargarAsientos(obraId: number) {
    try {
      const response = await fetch(`http://dramaskBack.retocsv.es:80/Obra/${obraId}`);
      if (!response.ok) {
        throw new Error('Failed to fetch obra details');
      }
      const obraData = await response.json();
      seats.value = obraData.asientos; // Asume que los asientos vienen en la respuesta
    } catch (error) {
      console.error('Error:', error);
    }
  }

  function onChooseSeat(asientoId: number, num_Asiento: number) {
    const seat = { asientoId, num_Asiento };
    choosenSeats.value.push(seat);
    sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
  }

  function onUnchooseSeat(asientoId: number) {
    choosenSeats.value = choosenSeats.value.filter(seat => seat.asientoId !== asientoId);
    sessionStorage.setItem('choosenSeats', JSON.stringify(choosenSeats.value));
  }

  async function updateSeatStatus() {
    try {
        // Crear un array de promesas para cada solicitud de actualización
        const updatePromises = choosenSeats.value.map(seat => 
            fetch(`http://dramaskBack.retocsv.es:80/Asiento/${seat.asientoId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ reservado: true }),
            })
        );

        // Esperar a que todas las solicitudes se completen
        const responses = await Promise.all(updatePromises);

        // Comprobar si alguna solicitud no fue exitosa
        const allSuccessful = responses.every(response => response.ok);
        if (!allSuccessful) {
            throw new Error('Error al actualizar uno o más asientos');
        }

        // Limpieza después de la actualización exitosa
        sessionStorage.removeItem('choosenSeats');
        choosenSeats.value = [];

        // Aquí puedes redirigir o mostrar un mensaje de éxito
    } catch (error) {
        console.error('Error al actualizar los asientos:', error);
    }
  }

  return { seats, choosenSeats, cargarAsientos, onChooseSeat, onUnchooseSeat, updateSeatStatus };
});
