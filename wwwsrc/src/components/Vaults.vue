<template>
  <div class="">
    <!-- <form @submit.prevent="addVault">
      <input type="text" v-model="newVault.Description" placeholder="description">
      <button type="submit">submit</button>
    </form>
    <div v-for="vault in Vaults">
      {{vault}}
        <button @click="setVault(vault)">Set Vault</button>
    </div> -->
  </div>
</template>

<script>
//   export default {
//     name: 'Vaults',
//     components: {},
//     data() {
//       return {
//         addVault: {
//           Description: "",
//         }
//       }
//     },
//     computed: {
//       Vaults() {
//       return this.$store.state.vaults
//     }
//     },
//     methods: {
//       addVault(){
//         this.$store.dispatch('addVault', this.newVault)
//       },
//       setVault(vault){
//         this.$store.dispatch('setVault', vault)
//       }
//     }
//   }
</script>

<style>
</style>